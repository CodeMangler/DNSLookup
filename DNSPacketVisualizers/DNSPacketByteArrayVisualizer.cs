using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.DebuggerVisualizers;
using CodeMangler.DNSPacketVisualizers;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(DNSPacketByteArrayVisualizer),
    typeof(VisualizerObjectSource), Target = typeof(CodeMangler.DNSLookup.DNS.Message),
    Description = DNSPacketByteArrayVisualizer.Description)]

namespace CodeMangler.DNSPacketVisualizers
{
    public class DNSPacketByteArrayVisualizer : DialogDebuggerVisualizer
    {
        public const string Description = "DNS Packet Byte Array Visualizer";

        protected override void Show(
            IDialogVisualizerService windowService,
            IVisualizerObjectProvider objectProvider)
        {
            object data = objectProvider.GetObject();

            using (Form f = new Form())
            using (ByteViewer viewer = new ByteViewer())
            {
                if (data is CodeMangler.DNSLookup.DNS.Message)
                    viewer.SetBytes(((CodeMangler.DNSLookup.DNS.Message) data).RawBytes);
                else return;

                viewer.SetDisplayMode(DisplayMode.Hexdump);
                viewer.Dock = DockStyle.Fill;

                f.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                f.Text = "DNS Packet Byte Array Viewer";
                f.ClientSize = viewer.Size;
                f.Controls.Add(viewer);

                windowService.ShowDialog(f);
            }
        }
    }
}