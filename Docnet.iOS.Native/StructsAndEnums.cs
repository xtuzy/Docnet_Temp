/*using System;
using System.Runtime.InteropServices;

namespace Docnet.Core
{
    public enum FpdfTextRendermode
    {
        Unknown = -1,
        Fill = 0,
        Stroke = 1,
        FillStroke = 2,
        Invisible = 3,
        FillClip = 4,
        StrokeClip = 5,
        FillStrokeClip = 6,
        Clip = 7,
        Last = Clip
    }

    public enum FpdfDuplextype : uint
    {
        DuplexUndefined = 0,
        Simplex,
        DuplexFlipShortEdge,
        DuplexFlipLongEdge
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_BSTR
    {
        public unsafe sbyte* str;

        public int len;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FS_MATRIX
    {
        public float a;

        public float b;

        public float c;

        public float d;

        public float e;

        public float f;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FS_RECTF
    {
        public float left;

        public float top;

        public float right;

        public float bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FS_SIZEF
    {
        public float width;

        public float height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FS_POINTF
    {
        public float x;

        public float y;
    }

    static class CFunctions
    {
        // extern void FPDF_InitLibrary ();
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern void FPDF_InitLibrary();

        // extern void FPDF_InitLibraryWithConfig (const FPDF_LIBRARY_CONFIG *config);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_InitLibraryWithConfig(FPDF_LIBRARY_CONFIG* config);

        // extern void FPDF_DestroyLibrary ();
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern void FPDF_DestroyLibrary();

        // extern void FPDF_SetSandBoxPolicy (FPDF_DWORD policy, FPDF_BOOL enable);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern void FPDF_SetSandBoxPolicy(nuint policy, int enable);

        // extern FPDF_DOCUMENT FPDF_LoadDocument (FPDF_STRING file_path, FPDF_BYTESTRING password);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DOCUMENT* FPDF_LoadDocument(sbyte* file_path, sbyte* password);

        // extern FPDF_DOCUMENT FPDF_LoadMemDocument (const void *data_buf, int size, FPDF_BYTESTRING password);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DOCUMENT* FPDF_LoadMemDocument(void* data_buf, int size, sbyte* password);

        // extern FPDF_DOCUMENT FPDF_LoadMemDocument64 (const void *data_buf, size_t size, FPDF_BYTESTRING password);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DOCUMENT* FPDF_LoadMemDocument64(void* data_buf, nuint size, sbyte* password);

        // extern FPDF_DOCUMENT FPDF_LoadCustomDocument (FPDF_FILEACCESS *pFileAccess, FPDF_BYTESTRING password);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DOCUMENT* FPDF_LoadCustomDocument(FPDF_FILEACCESS* pFileAccess, sbyte* password);

        // extern FPDF_BOOL FPDF_GetFileVersion (FPDF_DOCUMENT doc, int *fileVersion);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetFileVersion(FPDF_DOCUMENT* doc, int* fileVersion);

        // extern unsigned long FPDF_GetLastError ();
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern nuint FPDF_GetLastError();

        // extern FPDF_BOOL FPDF_DocumentHasValidCrossReferenceTable (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_DocumentHasValidCrossReferenceTable(FPDF_DOCUMENT* document);

        // extern unsigned long FPDF_GetTrailerEnds (FPDF_DOCUMENT document, unsigned int *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_GetTrailerEnds(FPDF_DOCUMENT* document, uint* buffer, nuint length);

        // extern unsigned long FPDF_GetDocPermissions (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_GetDocPermissions(FPDF_DOCUMENT* document);

        // extern int FPDF_GetSecurityHandlerRevision (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetSecurityHandlerRevision(FPDF_DOCUMENT* document);

        // extern int FPDF_GetPageCount (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetPageCount(FPDF_DOCUMENT* document);

        // extern FPDF_PAGE FPDF_LoadPage (FPDF_DOCUMENT document, int page_index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGE* FPDF_LoadPage(FPDF_DOCUMENT* document, int page_index);

        // extern float FPDF_GetPageWidthF (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe float FPDF_GetPageWidthF(FPDF_PAGE* page);

        // extern double FPDF_GetPageWidth (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe double FPDF_GetPageWidth(FPDF_PAGE* page);

        // extern float FPDF_GetPageHeightF (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe float FPDF_GetPageHeightF(FPDF_PAGE* page);

        // extern double FPDF_GetPageHeight (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe double FPDF_GetPageHeight(FPDF_PAGE* page);

        // extern FPDF_BOOL FPDF_GetPageBoundingBox (FPDF_PAGE page, FS_RECTF *rect);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetPageBoundingBox(FPDF_PAGE* page, FS_RECTF* rect);

        // extern FPDF_BOOL FPDF_GetPageSizeByIndexF (FPDF_DOCUMENT document, int page_index, FS_SIZEF *size);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetPageSizeByIndexF(FPDF_DOCUMENT* document, int page_index, FS_SIZEF* size);

        // extern int FPDF_GetPageSizeByIndex (FPDF_DOCUMENT document, int page_index, double *width, double *height);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetPageSizeByIndex(FPDF_DOCUMENT* document, int page_index, double* width, double* height);

        // extern void FPDF_RenderPageBitmap (FPDF_BITMAP bitmap, FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_RenderPageBitmap(FPDF_BITMAP* bitmap, FPDF_PAGE* page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);

        // extern void FPDF_RenderPageBitmapWithMatrix (FPDF_BITMAP bitmap, FPDF_PAGE page, const FS_MATRIX *matrix, const FS_RECTF *clipping, int flags);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_RenderPageBitmapWithMatrix(FPDF_BITMAP* bitmap, FPDF_PAGE* page, FS_MATRIX* matrix, FS_RECTF* clipping, int flags);

        // extern void FPDF_ClosePage (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_ClosePage(FPDF_PAGE* page);

        // extern void FPDF_CloseDocument (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_CloseDocument(FPDF_DOCUMENT* document);

        // extern FPDF_BOOL FPDF_DeviceToPage (FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, int device_x, int device_y, double *page_x, double *page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_DeviceToPage(FPDF_PAGE* page, int start_x, int start_y, int size_x, int size_y, int rotate, int device_x, int device_y, double* page_x, double* page_y);

        // extern FPDF_BOOL FPDF_PageToDevice (FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, double page_x, double page_y, int *device_x, int *device_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_PageToDevice(FPDF_PAGE* page, int start_x, int start_y, int size_x, int size_y, int rotate, double page_x, double page_y, int* device_x, int* device_y);

        // extern FPDF_BITMAP FPDFBitmap_Create (int width, int height, int alpha);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_BITMAP* FPDFBitmap_Create(int width, int height, int alpha);

        // extern FPDF_BITMAP FPDFBitmap_CreateEx (int width, int height, int format, void *first_scan, int stride);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_BITMAP* FPDFBitmap_CreateEx(int width, int height, int format, void* first_scan, int stride);

        // extern int FPDFBitmap_GetFormat (FPDF_BITMAP bitmap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFBitmap_GetFormat(FPDF_BITMAP* bitmap);

        // extern void FPDFBitmap_FillRect (FPDF_BITMAP bitmap, int left, int top, int width, int height, FPDF_DWORD color);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFBitmap_FillRect(FPDF_BITMAP* bitmap, int left, int top, int width, int height, nuint color);

        // extern void * FPDFBitmap_GetBuffer (FPDF_BITMAP bitmap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void* FPDFBitmap_GetBuffer(FPDF_BITMAP* bitmap);

        // extern int FPDFBitmap_GetWidth (FPDF_BITMAP bitmap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFBitmap_GetWidth(FPDF_BITMAP* bitmap);

        // extern int FPDFBitmap_GetHeight (FPDF_BITMAP bitmap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFBitmap_GetHeight(FPDF_BITMAP* bitmap);

        // extern int FPDFBitmap_GetStride (FPDF_BITMAP bitmap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFBitmap_GetStride(FPDF_BITMAP* bitmap);

        // extern void FPDFBitmap_Destroy (FPDF_BITMAP bitmap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFBitmap_Destroy(FPDF_BITMAP* bitmap);

        // extern FPDF_BOOL FPDF_VIEWERREF_GetPrintScaling (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_VIEWERREF_GetPrintScaling(FPDF_DOCUMENT* document);

        // extern int FPDF_VIEWERREF_GetNumCopies (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_VIEWERREF_GetNumCopies(FPDF_DOCUMENT* document);

        // extern FPDF_PAGERANGE FPDF_VIEWERREF_GetPrintPageRange (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGERANGE* FPDF_VIEWERREF_GetPrintPageRange(FPDF_DOCUMENT* document);

        // extern size_t FPDF_VIEWERREF_GetPrintPageRangeCount (FPDF_PAGERANGE pagerange);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_VIEWERREF_GetPrintPageRangeCount(FPDF_PAGERANGE* pagerange);

        // extern int FPDF_VIEWERREF_GetPrintPageRangeElement (FPDF_PAGERANGE pagerange, size_t index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_VIEWERREF_GetPrintPageRangeElement(FPDF_PAGERANGE* pagerange, nuint index);

        // extern FPDF_DUPLEXTYPE FPDF_VIEWERREF_GetDuplex (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FpdfDuplextype FPDF_VIEWERREF_GetDuplex(FPDF_DOCUMENT* document);

        // extern unsigned long FPDF_VIEWERREF_GetName (FPDF_DOCUMENT document, FPDF_BYTESTRING key, char *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_VIEWERREF_GetName(FPDF_DOCUMENT* document, sbyte* key, sbyte* buffer, nuint length);

        // extern FPDF_DWORD FPDF_CountNamedDests (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_CountNamedDests(FPDF_DOCUMENT* document);

        // extern FPDF_DEST FPDF_GetNamedDestByName (FPDF_DOCUMENT document, FPDF_BYTESTRING name);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DEST* FPDF_GetNamedDestByName(FPDF_DOCUMENT* document, sbyte* name);

        // extern FPDF_DEST FPDF_GetNamedDest (FPDF_DOCUMENT document, int index, void *buffer, long *buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DEST* FPDF_GetNamedDest(FPDF_DOCUMENT* document, int index, void* buffer, nint* buflen);

        // extern int FPDF_GetXFAPacketCount (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetXFAPacketCount(FPDF_DOCUMENT* document);

        // extern unsigned long FPDF_GetXFAPacketName (FPDF_DOCUMENT document, int index, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_GetXFAPacketName(FPDF_DOCUMENT* document, int index, void* buffer, nuint buflen);

        // extern FPDF_BOOL FPDF_GetXFAPacketContent (FPDF_DOCUMENT document, int index, void *buffer, unsigned long buflen, unsigned long *out_buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetXFAPacketContent(FPDF_DOCUMENT* document, int index, void* buffer, nuint buflen, nuint* out_buflen);

        // extern FPDF_BOOKMARK FPDFBookmark_GetFirstChild (FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_BOOKMARK* FPDFBookmark_GetFirstChild(FPDF_DOCUMENT* document, FPDF_BOOKMARK* bookmark);

        // extern FPDF_BOOKMARK FPDFBookmark_GetNextSibling (FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_BOOKMARK* FPDFBookmark_GetNextSibling(FPDF_DOCUMENT* document, FPDF_BOOKMARK* bookmark);

        // extern unsigned long FPDFBookmark_GetTitle (FPDF_BOOKMARK bookmark, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFBookmark_GetTitle(FPDF_BOOKMARK* bookmark, void* buffer, nuint buflen);

        // extern FPDF_BOOKMARK FPDFBookmark_Find (FPDF_DOCUMENT document, FPDF_WIDESTRING title);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_BOOKMARK* FPDFBookmark_Find(FPDF_DOCUMENT* document, ushort* title);

        // extern FPDF_DEST FPDFBookmark_GetDest (FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DEST* FPDFBookmark_GetDest(FPDF_DOCUMENT* document, FPDF_BOOKMARK* bookmark);

        // extern FPDF_ACTION FPDFBookmark_GetAction (FPDF_BOOKMARK bookmark);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ACTION* FPDFBookmark_GetAction(FPDF_BOOKMARK* bookmark);

        // extern unsigned long FPDFAction_GetType (FPDF_ACTION action);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAction_GetType(FPDF_ACTION* action);

        // extern FPDF_DEST FPDFAction_GetDest (FPDF_DOCUMENT document, FPDF_ACTION action);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DEST* FPDFAction_GetDest(FPDF_DOCUMENT* document, FPDF_ACTION* action);

        // extern unsigned long FPDFAction_GetFilePath (FPDF_ACTION action, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAction_GetFilePath(FPDF_ACTION* action, void* buffer, nuint buflen);

        // extern unsigned long FPDFAction_GetURIPath (FPDF_DOCUMENT document, FPDF_ACTION action, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAction_GetURIPath(FPDF_DOCUMENT* document, FPDF_ACTION* action, void* buffer, nuint buflen);

        // extern int FPDFDest_GetDestPageIndex (FPDF_DOCUMENT document, FPDF_DEST dest);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFDest_GetDestPageIndex(FPDF_DOCUMENT* document, FPDF_DEST* dest);

        // extern unsigned long FPDFDest_GetView (FPDF_DEST dest, unsigned long *pNumParams, FS_FLOAT *pParams);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFDest_GetView(FPDF_DEST* dest, nuint* pNumParams, float* pParams);

        // extern FPDF_BOOL FPDFDest_GetLocationInPage (FPDF_DEST dest, FPDF_BOOL *hasXVal, FPDF_BOOL *hasYVal, FPDF_BOOL *hasZoomVal, FS_FLOAT *x, FS_FLOAT *y, FS_FLOAT *zoom);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFDest_GetLocationInPage(FPDF_DEST* dest, int* hasXVal, int* hasYVal, int* hasZoomVal, float* x, float* y, float* zoom);

        // extern FPDF_LINK FPDFLink_GetLinkAtPoint (FPDF_PAGE page, double x, double y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_LINK* FPDFLink_GetLinkAtPoint(FPDF_PAGE* page, double x, double y);

        // extern int FPDFLink_GetLinkZOrderAtPoint (FPDF_PAGE page, double x, double y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_GetLinkZOrderAtPoint(FPDF_PAGE* page, double x, double y);

        // extern FPDF_DEST FPDFLink_GetDest (FPDF_DOCUMENT document, FPDF_LINK link);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DEST* FPDFLink_GetDest(FPDF_DOCUMENT* document, FPDF_LINK* link);

        // extern FPDF_ACTION FPDFLink_GetAction (FPDF_LINK link);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ACTION* FPDFLink_GetAction(FPDF_LINK* link);

        // extern FPDF_BOOL FPDFLink_Enumerate (FPDF_PAGE page, int *start_pos, FPDF_LINK *link_annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_Enumerate(FPDF_PAGE* page, int* start_pos, FPDF_LINK** link_annot);

        // extern FPDF_ANNOTATION FPDFLink_GetAnnot (FPDF_PAGE page, FPDF_LINK link_annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ANNOTATION* FPDFLink_GetAnnot(FPDF_PAGE* page, FPDF_LINK* link_annot);

        // extern FPDF_BOOL FPDFLink_GetAnnotRect (FPDF_LINK link_annot, FS_RECTF *rect);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_GetAnnotRect(FPDF_LINK* link_annot, FS_RECTF* rect);

        // extern int FPDFLink_CountQuadPoints (FPDF_LINK link_annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_CountQuadPoints(FPDF_LINK* link_annot);

        // extern FPDF_BOOL FPDFLink_GetQuadPoints (FPDF_LINK link_annot, int quad_index, FS_QUADPOINTSF *quad_points);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_GetQuadPoints(FPDF_LINK* link_annot, int quad_index, FS_QUADPOINTSF* quad_points);

        // extern FPDF_ACTION FPDF_GetPageAAction (FPDF_PAGE page, int aa_type);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ACTION* FPDF_GetPageAAction(FPDF_PAGE* page, int aa_type);

        // extern unsigned long FPDF_GetFileIdentifier (FPDF_DOCUMENT document, FPDF_FILEIDTYPE id_type, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_GetFileIdentifier(FPDF_DOCUMENT* document, FPDF_FILEIDTYPE id_type, void* buffer, nuint buflen);

        // extern unsigned long FPDF_GetMetaText (FPDF_DOCUMENT document, FPDF_BYTESTRING tag, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_GetMetaText(FPDF_DOCUMENT* document, sbyte* tag, void* buffer, nuint buflen);

        // extern unsigned long FPDF_GetPageLabel (FPDF_DOCUMENT document, int page_index, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_GetPageLabel(FPDF_DOCUMENT* document, int page_index, void* buffer, nuint buflen);

        // extern FPDF_FORMHANDLE FPDFDOC_InitFormFillEnvironment (FPDF_DOCUMENT document, FPDF_FORMFILLINFO *formInfo);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_FORMHANDLE* FPDFDOC_InitFormFillEnvironment(FPDF_DOCUMENT* document, FPDF_FORMFILLINFO* formInfo);

        // extern void FPDFDOC_ExitFormFillEnvironment (FPDF_FORMHANDLE hHandle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFDOC_ExitFormFillEnvironment(FPDF_FORMHANDLE* hHandle);

        // extern void FORM_OnAfterLoadPage (FPDF_PAGE page, FPDF_FORMHANDLE hHandle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FORM_OnAfterLoadPage(FPDF_PAGE* page, FPDF_FORMHANDLE* hHandle);

        // extern void FORM_OnBeforeClosePage (FPDF_PAGE page, FPDF_FORMHANDLE hHandle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FORM_OnBeforeClosePage(FPDF_PAGE* page, FPDF_FORMHANDLE* hHandle);

        // extern void FORM_DoDocumentJSAction (FPDF_FORMHANDLE hHandle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FORM_DoDocumentJSAction(FPDF_FORMHANDLE* hHandle);

        // extern void FORM_DoDocumentOpenAction (FPDF_FORMHANDLE hHandle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FORM_DoDocumentOpenAction(FPDF_FORMHANDLE* hHandle);

        // extern void FORM_DoDocumentAAction (FPDF_FORMHANDLE hHandle, int aaType);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FORM_DoDocumentAAction(FPDF_FORMHANDLE* hHandle, int aaType);

        // extern void FORM_DoPageAAction (FPDF_PAGE page, FPDF_FORMHANDLE hHandle, int aaType);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FORM_DoPageAAction(FPDF_PAGE* page, FPDF_FORMHANDLE* hHandle, int aaType);

        // extern FPDF_BOOL FORM_OnMouseMove (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int modifier, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnMouseMove(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int modifier, double page_x, double page_y);

        // extern FPDF_BOOL FORM_OnMouseWheel (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int modifier, const FS_POINTF *page_coord, int delta_x, int delta_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnMouseWheel(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int modifier, FS_POINTF* page_coord, int delta_x, int delta_y);

        // extern FPDF_BOOL FORM_OnFocus (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int modifier, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnFocus(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int modifier, double page_x, double page_y);

        // extern FPDF_BOOL FORM_OnLButtonDown (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int modifier, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnLButtonDown(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int modifier, double page_x, double page_y);

        // extern FPDF_BOOL FORM_OnRButtonDown (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int modifier, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnRButtonDown(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int modifier, double page_x, double page_y);

        // extern FPDF_BOOL FORM_OnLButtonUp (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int modifier, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnLButtonUp(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int modifier, double page_x, double page_y);

        // extern FPDF_BOOL FORM_OnRButtonUp (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int modifier, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnRButtonUp(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int modifier, double page_x, double page_y);

        // extern FPDF_BOOL FORM_OnLButtonDoubleClick (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int modifier, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnLButtonDoubleClick(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int modifier, double page_x, double page_y);

        // extern FPDF_BOOL FORM_OnKeyDown (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int nKeyCode, int modifier);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnKeyDown(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int nKeyCode, int modifier);

        // extern FPDF_BOOL FORM_OnKeyUp (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int nKeyCode, int modifier);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnKeyUp(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int nKeyCode, int modifier);

        // extern FPDF_BOOL FORM_OnChar (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int nChar, int modifier);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_OnChar(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int nChar, int modifier);

        // extern unsigned long FORM_GetFocusedText (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FORM_GetFocusedText(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, void* buffer, nuint buflen);

        // extern unsigned long FORM_GetSelectedText (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FORM_GetSelectedText(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, void* buffer, nuint buflen);

        // extern void FORM_ReplaceSelection (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, FPDF_WIDESTRING wsText);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FORM_ReplaceSelection(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, ushort* wsText);

        // extern FPDF_BOOL FORM_SelectAllText (FPDF_FORMHANDLE hHandle, FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_SelectAllText(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page);

        // extern FPDF_BOOL FORM_CanUndo (FPDF_FORMHANDLE hHandle, FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_CanUndo(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page);

        // extern FPDF_BOOL FORM_CanRedo (FPDF_FORMHANDLE hHandle, FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_CanRedo(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page);

        // extern FPDF_BOOL FORM_Undo (FPDF_FORMHANDLE hHandle, FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_Undo(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page);

        // extern FPDF_BOOL FORM_Redo (FPDF_FORMHANDLE hHandle, FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_Redo(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page);

        // extern FPDF_BOOL FORM_ForceToKillFocus (FPDF_FORMHANDLE hHandle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_ForceToKillFocus(FPDF_FORMHANDLE* hHandle);

        // extern FPDF_BOOL FORM_GetFocusedAnnot (FPDF_FORMHANDLE handle, int *page_index, FPDF_ANNOTATION *annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_GetFocusedAnnot(FPDF_FORMHANDLE* handle, int* page_index, FPDF_ANNOTATION** annot);

        // extern FPDF_BOOL FORM_SetFocusedAnnot (FPDF_FORMHANDLE handle, FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_SetFocusedAnnot(FPDF_FORMHANDLE* handle, FPDF_ANNOTATION* annot);

        // extern int FPDFPage_HasFormFieldAtPoint (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_HasFormFieldAtPoint(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, double page_x, double page_y);

        // extern int FPDFPage_FormFieldZOrderAtPoint (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, double page_x, double page_y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_FormFieldZOrderAtPoint(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, double page_x, double page_y);

        // extern void FPDF_SetFormFieldHighlightColor (FPDF_FORMHANDLE hHandle, int fieldType, unsigned long color);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_SetFormFieldHighlightColor(FPDF_FORMHANDLE* hHandle, int fieldType, nuint color);

        // extern void FPDF_SetFormFieldHighlightAlpha (FPDF_FORMHANDLE hHandle, unsigned char alpha);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_SetFormFieldHighlightAlpha(FPDF_FORMHANDLE* hHandle, byte alpha);

        // extern void FPDF_RemoveFormFieldHighlight (FPDF_FORMHANDLE hHandle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_RemoveFormFieldHighlight(FPDF_FORMHANDLE* hHandle);

        // extern void FPDF_FFLDraw (FPDF_FORMHANDLE hHandle, FPDF_BITMAP bitmap, FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_FFLDraw(FPDF_FORMHANDLE* hHandle, FPDF_BITMAP* bitmap, FPDF_PAGE* page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);

        // extern int FPDF_GetFormType (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetFormType(FPDF_DOCUMENT* document);

        // extern FPDF_BOOL FORM_SetIndexSelected (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int index, FPDF_BOOL selected);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_SetIndexSelected(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int index, int selected);

        // extern FPDF_BOOL FORM_IsIndexSelected (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FORM_IsIndexSelected(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, int index);

        // extern FPDF_BOOL FPDF_LoadXFA (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_LoadXFA(FPDF_DOCUMENT* document);

        // extern FPDF_BOOL FPDFAnnot_IsSupportedSubtype (FPDF_ANNOTATION_SUBTYPE subtype);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern int FPDFAnnot_IsSupportedSubtype(int subtype);

        // extern FPDF_ANNOTATION FPDFPage_CreateAnnot (FPDF_PAGE page, FPDF_ANNOTATION_SUBTYPE subtype);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ANNOTATION* FPDFPage_CreateAnnot(FPDF_PAGE* page, int subtype);

        // extern int FPDFPage_GetAnnotCount (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GetAnnotCount(FPDF_PAGE* page);

        // extern FPDF_ANNOTATION FPDFPage_GetAnnot (FPDF_PAGE page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ANNOTATION* FPDFPage_GetAnnot(FPDF_PAGE* page, int index);

        // extern int FPDFPage_GetAnnotIndex (FPDF_PAGE page, FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GetAnnotIndex(FPDF_PAGE* page, FPDF_ANNOTATION* annot);

        // extern void FPDFPage_CloseAnnot (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_CloseAnnot(FPDF_ANNOTATION* annot);

        // extern FPDF_BOOL FPDFPage_RemoveAnnot (FPDF_PAGE page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_RemoveAnnot(FPDF_PAGE* page, int index);

        // extern FPDF_ANNOTATION_SUBTYPE FPDFAnnot_GetSubtype (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetSubtype(FPDF_ANNOTATION* annot);

        // extern FPDF_BOOL FPDFAnnot_IsObjectSupportedSubtype (FPDF_ANNOTATION_SUBTYPE subtype);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern int FPDFAnnot_IsObjectSupportedSubtype(int subtype);

        // extern FPDF_BOOL FPDFAnnot_UpdateObject (FPDF_ANNOTATION annot, FPDF_PAGEOBJECT obj);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_UpdateObject(FPDF_ANNOTATION* annot, FPDF_PAGEOBJECT* obj);

        // extern int FPDFAnnot_AddInkStroke (FPDF_ANNOTATION annot, const FS_POINTF *points, size_t point_count);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_AddInkStroke(FPDF_ANNOTATION* annot, FS_POINTF* points, nuint point_count);

        // extern FPDF_BOOL FPDFAnnot_RemoveInkList (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_RemoveInkList(FPDF_ANNOTATION* annot);

        // extern FPDF_BOOL FPDFAnnot_AppendObject (FPDF_ANNOTATION annot, FPDF_PAGEOBJECT obj);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_AppendObject(FPDF_ANNOTATION* annot, FPDF_PAGEOBJECT* obj);

        // extern int FPDFAnnot_GetObjectCount (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetObjectCount(FPDF_ANNOTATION* annot);

        // extern FPDF_PAGEOBJECT FPDFAnnot_GetObject (FPDF_ANNOTATION annot, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECT* FPDFAnnot_GetObject(FPDF_ANNOTATION* annot, int index);

        // extern FPDF_BOOL FPDFAnnot_RemoveObject (FPDF_ANNOTATION annot, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_RemoveObject(FPDF_ANNOTATION* annot, int index);

        // extern FPDF_BOOL FPDFAnnot_SetColor (FPDF_ANNOTATION annot, FPDFANNOT_COLORTYPE type, unsigned int R, unsigned int G, unsigned int B, unsigned int A);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_SetColor(FPDF_ANNOTATION* annot, FPDFANNOT_COLORTYPE type, uint R, uint G, uint B, uint A);

        // extern FPDF_BOOL FPDFAnnot_GetColor (FPDF_ANNOTATION annot, FPDFANNOT_COLORTYPE type, unsigned int *R, unsigned int *G, unsigned int *B, unsigned int *A);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetColor(FPDF_ANNOTATION* annot, FPDFANNOT_COLORTYPE type, uint* R, uint* G, uint* B, uint* A);

        // extern FPDF_BOOL FPDFAnnot_HasAttachmentPoints (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_HasAttachmentPoints(FPDF_ANNOTATION* annot);

        // extern FPDF_BOOL FPDFAnnot_SetAttachmentPoints (FPDF_ANNOTATION annot, size_t quad_index, const FS_QUADPOINTSF *quad_points);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_SetAttachmentPoints(FPDF_ANNOTATION* annot, nuint quad_index, FS_QUADPOINTSF* quad_points);

        // extern FPDF_BOOL FPDFAnnot_AppendAttachmentPoints (FPDF_ANNOTATION annot, const FS_QUADPOINTSF *quad_points);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_AppendAttachmentPoints(FPDF_ANNOTATION* annot, FS_QUADPOINTSF* quad_points);

        // extern size_t FPDFAnnot_CountAttachmentPoints (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_CountAttachmentPoints(FPDF_ANNOTATION* annot);

        // extern FPDF_BOOL FPDFAnnot_GetAttachmentPoints (FPDF_ANNOTATION annot, size_t quad_index, FS_QUADPOINTSF *quad_points);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetAttachmentPoints(FPDF_ANNOTATION* annot, nuint quad_index, FS_QUADPOINTSF* quad_points);

        // extern FPDF_BOOL FPDFAnnot_SetRect (FPDF_ANNOTATION annot, const FS_RECTF *rect);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_SetRect(FPDF_ANNOTATION* annot, FS_RECTF* rect);

        // extern FPDF_BOOL FPDFAnnot_GetRect (FPDF_ANNOTATION annot, FS_RECTF *rect);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetRect(FPDF_ANNOTATION* annot, FS_RECTF* rect);

        // extern unsigned long FPDFAnnot_GetVertices (FPDF_ANNOTATION annot, FS_POINTF *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetVertices(FPDF_ANNOTATION* annot, FS_POINTF* buffer, nuint length);

        // extern unsigned long FPDFAnnot_GetInkListCount (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetInkListCount(FPDF_ANNOTATION* annot);

        // extern unsigned long FPDFAnnot_GetInkListPath (FPDF_ANNOTATION annot, unsigned long path_index, FS_POINTF *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetInkListPath(FPDF_ANNOTATION* annot, nuint path_index, FS_POINTF* buffer, nuint length);

        // extern FPDF_BOOL FPDFAnnot_GetLine (FPDF_ANNOTATION annot, FS_POINTF *start, FS_POINTF *end);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetLine(FPDF_ANNOTATION* annot, FS_POINTF* start, FS_POINTF* end);

        // extern FPDF_BOOL FPDFAnnot_GetBorder (FPDF_ANNOTATION annot, float *horizontal_radius, float *vertical_radius, float *border_width);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetBorder(FPDF_ANNOTATION* annot, float* horizontal_radius, float* vertical_radius, float* border_width);

        // extern FPDF_BOOL FPDFAnnot_HasKey (FPDF_ANNOTATION annot, FPDF_BYTESTRING key);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_HasKey(FPDF_ANNOTATION* annot, sbyte* key);

        // extern FPDF_OBJECT_TYPE FPDFAnnot_GetValueType (FPDF_ANNOTATION annot, FPDF_BYTESTRING key);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetValueType(FPDF_ANNOTATION* annot, sbyte* key);

        // extern FPDF_BOOL FPDFAnnot_SetStringValue (FPDF_ANNOTATION annot, FPDF_BYTESTRING key, FPDF_WIDESTRING value);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_SetStringValue(FPDF_ANNOTATION* annot, sbyte* key, ushort* value);

        // extern unsigned long FPDFAnnot_GetStringValue (FPDF_ANNOTATION annot, FPDF_BYTESTRING key, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetStringValue(FPDF_ANNOTATION* annot, sbyte* key, ushort* buffer, nuint buflen);

        // extern FPDF_BOOL FPDFAnnot_GetNumberValue (FPDF_ANNOTATION annot, FPDF_BYTESTRING key, float *value);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetNumberValue(FPDF_ANNOTATION* annot, sbyte* key, float* value);

        // extern FPDF_BOOL FPDFAnnot_SetAP (FPDF_ANNOTATION annot, FPDF_ANNOT_APPEARANCEMODE appearanceMode, FPDF_WIDESTRING value);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_SetAP(FPDF_ANNOTATION* annot, int appearanceMode, ushort* value);

        // extern unsigned long FPDFAnnot_GetAP (FPDF_ANNOTATION annot, FPDF_ANNOT_APPEARANCEMODE appearanceMode, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetAP(FPDF_ANNOTATION* annot, int appearanceMode, ushort* buffer, nuint buflen);

        // extern FPDF_ANNOTATION FPDFAnnot_GetLinkedAnnot (FPDF_ANNOTATION annot, FPDF_BYTESTRING key);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ANNOTATION* FPDFAnnot_GetLinkedAnnot(FPDF_ANNOTATION* annot, sbyte* key);

        // extern int FPDFAnnot_GetFlags (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetFlags(FPDF_ANNOTATION* annot);

        // extern FPDF_BOOL FPDFAnnot_SetFlags (FPDF_ANNOTATION annot, int flags);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_SetFlags(FPDF_ANNOTATION* annot, int flags);

        // extern int FPDFAnnot_GetFormFieldFlags (FPDF_FORMHANDLE handle, FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetFormFieldFlags(FPDF_FORMHANDLE* handle, FPDF_ANNOTATION* annot);

        // extern FPDF_ANNOTATION FPDFAnnot_GetFormFieldAtPoint (FPDF_FORMHANDLE hHandle, FPDF_PAGE page, const FS_POINTF *point);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ANNOTATION* FPDFAnnot_GetFormFieldAtPoint(FPDF_FORMHANDLE* hHandle, FPDF_PAGE* page, FS_POINTF* point);

        // extern unsigned long FPDFAnnot_GetFormFieldName (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetFormFieldName(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot, ushort* buffer, nuint buflen);

        // extern int FPDFAnnot_GetFormFieldType (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetFormFieldType(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot);

        // extern unsigned long FPDFAnnot_GetFormFieldValue (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetFormFieldValue(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot, ushort* buffer, nuint buflen);

        // extern int FPDFAnnot_GetOptionCount (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetOptionCount(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot);

        // extern unsigned long FPDFAnnot_GetOptionLabel (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot, int index, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetOptionLabel(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot, int index, ushort* buffer, nuint buflen);

        // extern FPDF_BOOL FPDFAnnot_IsOptionSelected (FPDF_FORMHANDLE handle, FPDF_ANNOTATION annot, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_IsOptionSelected(FPDF_FORMHANDLE* handle, FPDF_ANNOTATION* annot, int index);

        // extern FPDF_BOOL FPDFAnnot_GetFontSize (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot, float *value);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetFontSize(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot, float* value);

        // extern FPDF_BOOL FPDFAnnot_IsChecked (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_IsChecked(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot);

        // extern FPDF_BOOL FPDFAnnot_SetFocusableSubtypes (FPDF_FORMHANDLE hHandle, const FPDF_ANNOTATION_SUBTYPE *subtypes, size_t count);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_SetFocusableSubtypes(FPDF_FORMHANDLE* hHandle, int* subtypes, nuint count);

        // extern int FPDFAnnot_GetFocusableSubtypesCount (FPDF_FORMHANDLE hHandle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetFocusableSubtypesCount(FPDF_FORMHANDLE* hHandle);

        // extern FPDF_BOOL FPDFAnnot_GetFocusableSubtypes (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION_SUBTYPE *subtypes, size_t count);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetFocusableSubtypes(FPDF_FORMHANDLE* hHandle, int* subtypes, nuint count);

        // extern FPDF_LINK FPDFAnnot_GetLink (FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_LINK* FPDFAnnot_GetLink(FPDF_ANNOTATION* annot);

        // extern int FPDFAnnot_GetFormControlCount (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetFormControlCount(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot);

        // extern int FPDFAnnot_GetFormControlIndex (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAnnot_GetFormControlIndex(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot);

        // extern unsigned long FPDFAnnot_GetFormFieldExportValue (FPDF_FORMHANDLE hHandle, FPDF_ANNOTATION annot, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAnnot_GetFormFieldExportValue(FPDF_FORMHANDLE* hHandle, FPDF_ANNOTATION* annot, ushort* buffer, nuint buflen);

        // extern int FPDFDoc_GetAttachmentCount (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFDoc_GetAttachmentCount(FPDF_DOCUMENT* document);

        // extern FPDF_ATTACHMENT FPDFDoc_AddAttachment (FPDF_DOCUMENT document, FPDF_WIDESTRING name);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ATTACHMENT* FPDFDoc_AddAttachment(FPDF_DOCUMENT* document, ushort* name);

        // extern FPDF_ATTACHMENT FPDFDoc_GetAttachment (FPDF_DOCUMENT document, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_ATTACHMENT* FPDFDoc_GetAttachment(FPDF_DOCUMENT* document, int index);

        // extern FPDF_BOOL FPDFDoc_DeleteAttachment (FPDF_DOCUMENT document, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFDoc_DeleteAttachment(FPDF_DOCUMENT* document, int index);

        // extern unsigned long FPDFAttachment_GetName (FPDF_ATTACHMENT attachment, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAttachment_GetName(FPDF_ATTACHMENT* attachment, ushort* buffer, nuint buflen);

        // extern FPDF_BOOL FPDFAttachment_HasKey (FPDF_ATTACHMENT attachment, FPDF_BYTESTRING key);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAttachment_HasKey(FPDF_ATTACHMENT* attachment, sbyte* key);

        // extern FPDF_OBJECT_TYPE FPDFAttachment_GetValueType (FPDF_ATTACHMENT attachment, FPDF_BYTESTRING key);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAttachment_GetValueType(FPDF_ATTACHMENT* attachment, sbyte* key);

        // extern FPDF_BOOL FPDFAttachment_SetStringValue (FPDF_ATTACHMENT attachment, FPDF_BYTESTRING key, FPDF_WIDESTRING value);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAttachment_SetStringValue(FPDF_ATTACHMENT* attachment, sbyte* key, ushort* value);

        // extern unsigned long FPDFAttachment_GetStringValue (FPDF_ATTACHMENT attachment, FPDF_BYTESTRING key, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFAttachment_GetStringValue(FPDF_ATTACHMENT* attachment, sbyte* key, ushort* buffer, nuint buflen);

        // extern FPDF_BOOL FPDFAttachment_SetFile (FPDF_ATTACHMENT attachment, FPDF_DOCUMENT document, const void *contents, unsigned long len);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAttachment_SetFile(FPDF_ATTACHMENT* attachment, FPDF_DOCUMENT* document, void* contents, nuint len);

        // extern FPDF_BOOL FPDFAttachment_GetFile (FPDF_ATTACHMENT attachment, void *buffer, unsigned long buflen, unsigned long *out_buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAttachment_GetFile(FPDF_ATTACHMENT* attachment, void* buffer, nuint buflen, nuint* out_buflen);

        // extern FPDF_BOOL FPDFCatalog_IsTagged (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFCatalog_IsTagged(FPDF_DOCUMENT* document);

        // extern FPDF_AVAIL FPDFAvail_Create (FX_FILEAVAIL *file_avail, FPDF_FILEACCESS *file);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void* FPDFAvail_Create(FX_FILEAVAIL* file_avail, FPDF_FILEACCESS* file);

        // extern void FPDFAvail_Destroy (FPDF_AVAIL avail);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFAvail_Destroy(void* avail);

        // extern int FPDFAvail_IsDocAvail (FPDF_AVAIL avail, FX_DOWNLOADHINTS *hints);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAvail_IsDocAvail(void* avail, FX_DOWNLOADHINTS* hints);

        // extern FPDF_DOCUMENT FPDFAvail_GetDocument (FPDF_AVAIL avail, FPDF_BYTESTRING password);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DOCUMENT* FPDFAvail_GetDocument(void* avail, sbyte* password);

        // extern int FPDFAvail_GetFirstPageNum (FPDF_DOCUMENT doc);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAvail_GetFirstPageNum(FPDF_DOCUMENT* doc);

        // extern int FPDFAvail_IsPageAvail (FPDF_AVAIL avail, int page_index, FX_DOWNLOADHINTS *hints);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAvail_IsPageAvail(void* avail, int page_index, FX_DOWNLOADHINTS* hints);

        // extern int FPDFAvail_IsFormAvail (FPDF_AVAIL avail, FX_DOWNLOADHINTS *hints);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAvail_IsFormAvail(void* avail, FX_DOWNLOADHINTS* hints);

        // extern int FPDFAvail_IsLinearized (FPDF_AVAIL avail);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFAvail_IsLinearized(void* avail);

        // extern FPDF_DOCUMENT FPDF_CreateNewDocument ();
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DOCUMENT* FPDF_CreateNewDocument();

        // extern FPDF_PAGE FPDFPage_New (FPDF_DOCUMENT document, int page_index, double width, double height);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGE* FPDFPage_New(FPDF_DOCUMENT* document, int page_index, double width, double height);

        // extern void FPDFPage_Delete (FPDF_DOCUMENT document, int page_index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_Delete(FPDF_DOCUMENT* document, int page_index);

        // extern int FPDFPage_GetRotation (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GetRotation(FPDF_PAGE* page);

        // extern void FPDFPage_SetRotation (FPDF_PAGE page, int rotate);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_SetRotation(FPDF_PAGE* page, int rotate);

        // extern void FPDFPage_InsertObject (FPDF_PAGE page, FPDF_PAGEOBJECT page_obj);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_InsertObject(FPDF_PAGE* page, FPDF_PAGEOBJECT* page_obj);

        // extern FPDF_BOOL FPDFPage_RemoveObject (FPDF_PAGE page, FPDF_PAGEOBJECT page_obj);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_RemoveObject(FPDF_PAGE* page, FPDF_PAGEOBJECT* page_obj);

        // extern int FPDFPage_CountObjects (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_CountObjects(FPDF_PAGE* page);

        // extern FPDF_PAGEOBJECT FPDFPage_GetObject (FPDF_PAGE page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECT* FPDFPage_GetObject(FPDF_PAGE* page, int index);

        // extern FPDF_BOOL FPDFPage_HasTransparency (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_HasTransparency(FPDF_PAGE* page);

        // extern FPDF_BOOL FPDFPage_GenerateContent (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GenerateContent(FPDF_PAGE* page);

        // extern void FPDFPageObj_Destroy (FPDF_PAGEOBJECT page_obj);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPageObj_Destroy(FPDF_PAGEOBJECT* page_obj);

        // extern FPDF_BOOL FPDFPageObj_HasTransparency (FPDF_PAGEOBJECT page_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_HasTransparency(FPDF_PAGEOBJECT* page_object);

        // extern int FPDFPageObj_GetType (FPDF_PAGEOBJECT page_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_GetType(FPDF_PAGEOBJECT* page_object);

        // extern void FPDFPageObj_Transform (FPDF_PAGEOBJECT page_object, double a, double b, double c, double d, double e, double f);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPageObj_Transform(FPDF_PAGEOBJECT* page_object, double a, double b, double c, double d, double e, double f);

        // extern void FPDFPage_TransformAnnots (FPDF_PAGE page, double a, double b, double c, double d, double e, double f);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_TransformAnnots(FPDF_PAGE* page, double a, double b, double c, double d, double e, double f);

        // extern FPDF_PAGEOBJECT FPDFPageObj_NewImageObj (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECT* FPDFPageObj_NewImageObj(FPDF_DOCUMENT* document);

        // extern int FPDFPageObj_CountMarks (FPDF_PAGEOBJECT page_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_CountMarks(FPDF_PAGEOBJECT* page_object);

        // extern FPDF_PAGEOBJECTMARK FPDFPageObj_GetMark (FPDF_PAGEOBJECT page_object, unsigned long index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECTMARK* FPDFPageObj_GetMark(FPDF_PAGEOBJECT* page_object, nuint index);

        // extern FPDF_PAGEOBJECTMARK FPDFPageObj_AddMark (FPDF_PAGEOBJECT page_object, FPDF_BYTESTRING name);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECTMARK* FPDFPageObj_AddMark(FPDF_PAGEOBJECT* page_object, sbyte* name);

        // extern FPDF_BOOL FPDFPageObj_RemoveMark (FPDF_PAGEOBJECT page_object, FPDF_PAGEOBJECTMARK mark);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_RemoveMark(FPDF_PAGEOBJECT* page_object, FPDF_PAGEOBJECTMARK* mark);

        // extern FPDF_BOOL FPDFPageObjMark_GetName (FPDF_PAGEOBJECTMARK mark, void *buffer, unsigned long buflen, unsigned long *out_buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_GetName(FPDF_PAGEOBJECTMARK* mark, void* buffer, nuint buflen, nuint* out_buflen);

        // extern int FPDFPageObjMark_CountParams (FPDF_PAGEOBJECTMARK mark);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_CountParams(FPDF_PAGEOBJECTMARK* mark);

        // extern FPDF_BOOL FPDFPageObjMark_GetParamKey (FPDF_PAGEOBJECTMARK mark, unsigned long index, void *buffer, unsigned long buflen, unsigned long *out_buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_GetParamKey(FPDF_PAGEOBJECTMARK* mark, nuint index, void* buffer, nuint buflen, nuint* out_buflen);

        // extern FPDF_OBJECT_TYPE FPDFPageObjMark_GetParamValueType (FPDF_PAGEOBJECTMARK mark, FPDF_BYTESTRING key);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_GetParamValueType(FPDF_PAGEOBJECTMARK* mark, sbyte* key);

        // extern FPDF_BOOL FPDFPageObjMark_GetParamIntValue (FPDF_PAGEOBJECTMARK mark, FPDF_BYTESTRING key, int *out_value);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_GetParamIntValue(FPDF_PAGEOBJECTMARK* mark, sbyte* key, int* out_value);

        // extern FPDF_BOOL FPDFPageObjMark_GetParamStringValue (FPDF_PAGEOBJECTMARK mark, FPDF_BYTESTRING key, void *buffer, unsigned long buflen, unsigned long *out_buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_GetParamStringValue(FPDF_PAGEOBJECTMARK* mark, sbyte* key, void* buffer, nuint buflen, nuint* out_buflen);

        // extern FPDF_BOOL FPDFPageObjMark_GetParamBlobValue (FPDF_PAGEOBJECTMARK mark, FPDF_BYTESTRING key, void *buffer, unsigned long buflen, unsigned long *out_buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_GetParamBlobValue(FPDF_PAGEOBJECTMARK* mark, sbyte* key, void* buffer, nuint buflen, nuint* out_buflen);

        // extern FPDF_BOOL FPDFPageObjMark_SetIntParam (FPDF_DOCUMENT document, FPDF_PAGEOBJECT page_object, FPDF_PAGEOBJECTMARK mark, FPDF_BYTESTRING key, int value);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_SetIntParam(FPDF_DOCUMENT* document, FPDF_PAGEOBJECT* page_object, FPDF_PAGEOBJECTMARK* mark, sbyte* key, int value);

        // extern FPDF_BOOL FPDFPageObjMark_SetStringParam (FPDF_DOCUMENT document, FPDF_PAGEOBJECT page_object, FPDF_PAGEOBJECTMARK mark, FPDF_BYTESTRING key, FPDF_BYTESTRING value);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_SetStringParam(FPDF_DOCUMENT* document, FPDF_PAGEOBJECT* page_object, FPDF_PAGEOBJECTMARK* mark, sbyte* key, sbyte* value);

        // extern FPDF_BOOL FPDFPageObjMark_SetBlobParam (FPDF_DOCUMENT document, FPDF_PAGEOBJECT page_object, FPDF_PAGEOBJECTMARK mark, FPDF_BYTESTRING key, void *value, unsigned long value_len);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_SetBlobParam(FPDF_DOCUMENT* document, FPDF_PAGEOBJECT* page_object, FPDF_PAGEOBJECTMARK* mark, sbyte* key, void* value, nuint value_len);

        // extern FPDF_BOOL FPDFPageObjMark_RemoveParam (FPDF_PAGEOBJECT page_object, FPDF_PAGEOBJECTMARK mark, FPDF_BYTESTRING key);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObjMark_RemoveParam(FPDF_PAGEOBJECT* page_object, FPDF_PAGEOBJECTMARK* mark, sbyte* key);

        // extern FPDF_BOOL FPDFImageObj_LoadJpegFile (FPDF_PAGE *pages, int count, FPDF_PAGEOBJECT image_object, FPDF_FILEACCESS *file_access);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFImageObj_LoadJpegFile(FPDF_PAGE** pages, int count, FPDF_PAGEOBJECT* image_object, FPDF_FILEACCESS* file_access);

        // extern FPDF_BOOL FPDFImageObj_LoadJpegFileInline (FPDF_PAGE *pages, int count, FPDF_PAGEOBJECT image_object, FPDF_FILEACCESS *file_access);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFImageObj_LoadJpegFileInline(FPDF_PAGE** pages, int count, FPDF_PAGEOBJECT* image_object, FPDF_FILEACCESS* file_access);

        // extern FPDF_BOOL FPDFImageObj_GetMatrix (FPDF_PAGEOBJECT image_object, double *a, double *b, double *c, double *d, double *e, double *f);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFImageObj_GetMatrix(FPDF_PAGEOBJECT* image_object, double* a, double* b, double* c, double* d, double* e, double* f);

        // extern FPDF_BOOL FPDFImageObj_SetMatrix (FPDF_PAGEOBJECT image_object, double a, double b, double c, double d, double e, double f);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFImageObj_SetMatrix(FPDF_PAGEOBJECT* image_object, double a, double b, double c, double d, double e, double f);

        // extern FPDF_BOOL FPDFImageObj_SetBitmap (FPDF_PAGE *pages, int count, FPDF_PAGEOBJECT image_object, FPDF_BITMAP bitmap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFImageObj_SetBitmap(FPDF_PAGE** pages, int count, FPDF_PAGEOBJECT* image_object, FPDF_BITMAP* bitmap);

        // extern FPDF_BITMAP FPDFImageObj_GetBitmap (FPDF_PAGEOBJECT image_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_BITMAP* FPDFImageObj_GetBitmap(FPDF_PAGEOBJECT* image_object);

        // extern FPDF_BITMAP FPDFImageObj_GetRenderedBitmap (FPDF_DOCUMENT document, FPDF_PAGE page, FPDF_PAGEOBJECT image_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_BITMAP* FPDFImageObj_GetRenderedBitmap(FPDF_DOCUMENT* document, FPDF_PAGE* page, FPDF_PAGEOBJECT* image_object);

        // extern unsigned long FPDFImageObj_GetImageDataDecoded (FPDF_PAGEOBJECT image_object, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFImageObj_GetImageDataDecoded(FPDF_PAGEOBJECT* image_object, void* buffer, nuint buflen);

        // extern unsigned long FPDFImageObj_GetImageDataRaw (FPDF_PAGEOBJECT image_object, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFImageObj_GetImageDataRaw(FPDF_PAGEOBJECT* image_object, void* buffer, nuint buflen);

        // extern int FPDFImageObj_GetImageFilterCount (FPDF_PAGEOBJECT image_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFImageObj_GetImageFilterCount(FPDF_PAGEOBJECT* image_object);

        // extern unsigned long FPDFImageObj_GetImageFilter (FPDF_PAGEOBJECT image_object, int index, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFImageObj_GetImageFilter(FPDF_PAGEOBJECT* image_object, int index, void* buffer, nuint buflen);

        // extern FPDF_BOOL FPDFImageObj_GetImageMetadata (FPDF_PAGEOBJECT image_object, FPDF_PAGE page, FPDF_IMAGEOBJ_METADATA *metadata);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFImageObj_GetImageMetadata(FPDF_PAGEOBJECT* image_object, FPDF_PAGE* page, FPDF_IMAGEOBJ_METADATA* metadata);

        // extern FPDF_PAGEOBJECT FPDFPageObj_CreateNewPath (float x, float y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECT* FPDFPageObj_CreateNewPath(float x, float y);

        // extern FPDF_PAGEOBJECT FPDFPageObj_CreateNewRect (float x, float y, float w, float h);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECT* FPDFPageObj_CreateNewRect(float x, float y, float w, float h);

        // extern FPDF_BOOL FPDFPageObj_GetBounds (FPDF_PAGEOBJECT page_object, float *left, float *bottom, float *right, float *top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_GetBounds(FPDF_PAGEOBJECT* page_object, float* left, float* bottom, float* right, float* top);

        // extern void FPDFPageObj_SetBlendMode (FPDF_PAGEOBJECT page_object, FPDF_BYTESTRING blend_mode);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPageObj_SetBlendMode(FPDF_PAGEOBJECT* page_object, sbyte* blend_mode);

        // extern FPDF_BOOL FPDFPageObj_SetStrokeColor (FPDF_PAGEOBJECT page_object, unsigned int R, unsigned int G, unsigned int B, unsigned int A);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_SetStrokeColor(FPDF_PAGEOBJECT* page_object, uint R, uint G, uint B, uint A);

        // extern FPDF_BOOL FPDFPageObj_GetStrokeColor (FPDF_PAGEOBJECT page_object, unsigned int *R, unsigned int *G, unsigned int *B, unsigned int *A);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_GetStrokeColor(FPDF_PAGEOBJECT* page_object, uint* R, uint* G, uint* B, uint* A);

        // extern FPDF_BOOL FPDFPageObj_SetStrokeWidth (FPDF_PAGEOBJECT page_object, float width);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_SetStrokeWidth(FPDF_PAGEOBJECT* page_object, float width);

        // extern FPDF_BOOL FPDFPageObj_GetStrokeWidth (FPDF_PAGEOBJECT page_object, float *width);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_GetStrokeWidth(FPDF_PAGEOBJECT* page_object, float* width);

        // extern int FPDFPageObj_GetLineJoin (FPDF_PAGEOBJECT page_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_GetLineJoin(FPDF_PAGEOBJECT* page_object);

        // extern FPDF_BOOL FPDFPageObj_SetLineJoin (FPDF_PAGEOBJECT page_object, int line_join);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_SetLineJoin(FPDF_PAGEOBJECT* page_object, int line_join);

        // extern int FPDFPageObj_GetLineCap (FPDF_PAGEOBJECT page_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_GetLineCap(FPDF_PAGEOBJECT* page_object);

        // extern FPDF_BOOL FPDFPageObj_SetLineCap (FPDF_PAGEOBJECT page_object, int line_cap);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_SetLineCap(FPDF_PAGEOBJECT* page_object, int line_cap);

        // extern FPDF_BOOL FPDFPageObj_SetFillColor (FPDF_PAGEOBJECT page_object, unsigned int R, unsigned int G, unsigned int B, unsigned int A);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_SetFillColor(FPDF_PAGEOBJECT* page_object, uint R, uint G, uint B, uint A);

        // extern FPDF_BOOL FPDFPageObj_GetFillColor (FPDF_PAGEOBJECT page_object, unsigned int *R, unsigned int *G, unsigned int *B, unsigned int *A);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPageObj_GetFillColor(FPDF_PAGEOBJECT* page_object, uint* R, uint* G, uint* B, uint* A);

        // extern int FPDFPath_CountSegments (FPDF_PAGEOBJECT path);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_CountSegments(FPDF_PAGEOBJECT* path);

        // extern FPDF_PATHSEGMENT FPDFPath_GetPathSegment (FPDF_PAGEOBJECT path, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PATHSEGMENT* FPDFPath_GetPathSegment(FPDF_PAGEOBJECT* path, int index);

        // extern FPDF_BOOL FPDFPathSegment_GetPoint (FPDF_PATHSEGMENT segment, float *x, float *y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPathSegment_GetPoint(FPDF_PATHSEGMENT* segment, float* x, float* y);

        // extern int FPDFPathSegment_GetType (FPDF_PATHSEGMENT segment);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPathSegment_GetType(FPDF_PATHSEGMENT* segment);

        // extern FPDF_BOOL FPDFPathSegment_GetClose (FPDF_PATHSEGMENT segment);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPathSegment_GetClose(FPDF_PATHSEGMENT* segment);

        // extern FPDF_BOOL FPDFPath_MoveTo (FPDF_PAGEOBJECT path, float x, float y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_MoveTo(FPDF_PAGEOBJECT* path, float x, float y);

        // extern FPDF_BOOL FPDFPath_LineTo (FPDF_PAGEOBJECT path, float x, float y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_LineTo(FPDF_PAGEOBJECT* path, float x, float y);

        // extern FPDF_BOOL FPDFPath_BezierTo (FPDF_PAGEOBJECT path, float x1, float y1, float x2, float y2, float x3, float y3);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_BezierTo(FPDF_PAGEOBJECT* path, float x1, float y1, float x2, float y2, float x3, float y3);

        // extern FPDF_BOOL FPDFPath_Close (FPDF_PAGEOBJECT path);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_Close(FPDF_PAGEOBJECT* path);

        // extern FPDF_BOOL FPDFPath_SetDrawMode (FPDF_PAGEOBJECT path, int fillmode, FPDF_BOOL stroke);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_SetDrawMode(FPDF_PAGEOBJECT* path, int fillmode, int stroke);

        // extern FPDF_BOOL FPDFPath_GetDrawMode (FPDF_PAGEOBJECT path, int *fillmode, FPDF_BOOL *stroke);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_GetDrawMode(FPDF_PAGEOBJECT* path, int* fillmode, int* stroke);

        // extern FPDF_BOOL FPDFPath_GetMatrix (FPDF_PAGEOBJECT path, FS_MATRIX *matrix);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_GetMatrix(FPDF_PAGEOBJECT* path, FS_MATRIX* matrix);

        // extern FPDF_BOOL FPDFPath_SetMatrix (FPDF_PAGEOBJECT path, const FS_MATRIX *matrix);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPath_SetMatrix(FPDF_PAGEOBJECT* path, FS_MATRIX* matrix);

        // extern FPDF_PAGEOBJECT FPDFPageObj_NewTextObj (FPDF_DOCUMENT document, FPDF_BYTESTRING font, float font_size);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECT* FPDFPageObj_NewTextObj(FPDF_DOCUMENT* document, sbyte* font, float font_size);

        // extern FPDF_BOOL FPDFText_SetText (FPDF_PAGEOBJECT text_object, FPDF_WIDESTRING text);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_SetText(FPDF_PAGEOBJECT* text_object, ushort* text);

        // extern FPDF_FONT FPDFText_LoadFont (FPDF_DOCUMENT document, const uint8_t *data, uint32_t size, int font_type, FPDF_BOOL cid);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_FONT* FPDFText_LoadFont(FPDF_DOCUMENT* document, byte* data, uint size, int font_type, int cid);

        // extern FPDF_FONT FPDFText_LoadStandardFont (FPDF_DOCUMENT document, FPDF_BYTESTRING font);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_FONT* FPDFText_LoadStandardFont(FPDF_DOCUMENT* document, sbyte* font);

        // extern FPDF_BOOL FPDFTextObj_GetMatrix (FPDF_PAGEOBJECT text, FS_MATRIX *matrix);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFTextObj_GetMatrix(FPDF_PAGEOBJECT* text, FS_MATRIX* matrix);

        // extern float FPDFTextObj_GetFontSize (FPDF_PAGEOBJECT text);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe float FPDFTextObj_GetFontSize(FPDF_PAGEOBJECT* text);

        // extern void FPDFFont_Close (FPDF_FONT font);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFFont_Close(FPDF_FONT* font);

        // extern FPDF_PAGEOBJECT FPDFPageObj_CreateTextObj (FPDF_DOCUMENT document, FPDF_FONT font, float font_size);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECT* FPDFPageObj_CreateTextObj(FPDF_DOCUMENT* document, FPDF_FONT* font, float font_size);

        // extern FPDF_TEXT_RENDERMODE FPDFTextObj_GetTextRenderMode (FPDF_PAGEOBJECT text);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FpdfTextRendermode FPDFTextObj_GetTextRenderMode(FPDF_PAGEOBJECT* text);

        // extern FPDF_BOOL FPDFTextObj_SetTextRenderMode (FPDF_PAGEOBJECT text, FPDF_TEXT_RENDERMODE render_mode);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFTextObj_SetTextRenderMode(FPDF_PAGEOBJECT* text, FpdfTextRendermode render_mode);

        // extern unsigned long FPDFTextObj_GetFontName (FPDF_PAGEOBJECT text, void *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFTextObj_GetFontName(FPDF_PAGEOBJECT* text, void* buffer, nuint length);

        // extern unsigned long FPDFTextObj_GetText (FPDF_PAGEOBJECT text_object, FPDF_TEXTPAGE text_page, void *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFTextObj_GetText(FPDF_PAGEOBJECT* text_object, FPDF_TEXTPAGE* text_page, void* buffer, nuint length);

        // extern int FPDFFormObj_CountObjects (FPDF_PAGEOBJECT form_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFFormObj_CountObjects(FPDF_PAGEOBJECT* form_object);

        // extern FPDF_PAGEOBJECT FPDFFormObj_GetObject (FPDF_PAGEOBJECT form_object, unsigned long index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGEOBJECT* FPDFFormObj_GetObject(FPDF_PAGEOBJECT* form_object, nuint index);

        // extern FPDF_BOOL FPDFFormObj_GetMatrix (FPDF_PAGEOBJECT form_object, FS_MATRIX *matrix);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFFormObj_GetMatrix(FPDF_PAGEOBJECT* form_object, FS_MATRIX* matrix);

        // extern FPDF_BOOL FSDK_SetUnSpObjProcessHandler (UNSUPPORT_INFO *unsp_info);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FSDK_SetUnSpObjProcessHandler(UNSUPPORT_INFO* unsp_info);

        // extern void FSDK_SetTimeFunction (time_t (* func)());
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FSDK_SetTimeFunction(Func<nint>* func);

        // extern void FSDK_SetLocaltimeFunction (struct tm * (* func)(const time_t *));
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FSDK_SetLocaltimeFunction(Func<nint*, tm*>* func);

        // extern int FPDFDoc_GetPageMode (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFDoc_GetPageMode(FPDF_DOCUMENT* document);

        // extern int FPDFPage_Flatten (FPDF_PAGE page, int nFlag);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_Flatten(FPDF_PAGE* page, int nFlag);

        // extern int FPDFDoc_GetJavaScriptActionCount (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFDoc_GetJavaScriptActionCount(FPDF_DOCUMENT* document);

        // extern FPDF_JAVASCRIPT_ACTION FPDFDoc_GetJavaScriptAction (FPDF_DOCUMENT document, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_JAVASCRIPT_ACTION* FPDFDoc_GetJavaScriptAction(FPDF_DOCUMENT* document, int index);

        // extern void FPDFDoc_CloseJavaScriptAction (FPDF_JAVASCRIPT_ACTION javascript);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFDoc_CloseJavaScriptAction(FPDF_JAVASCRIPT_ACTION* javascript);

        // extern unsigned long FPDFJavaScriptAction_GetName (FPDF_JAVASCRIPT_ACTION javascript, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFJavaScriptAction_GetName(FPDF_JAVASCRIPT_ACTION* javascript, ushort* buffer, nuint buflen);

        // extern unsigned long FPDFJavaScriptAction_GetScript (FPDF_JAVASCRIPT_ACTION javascript, FPDF_WCHAR *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFJavaScriptAction_GetScript(FPDF_JAVASCRIPT_ACTION* javascript, ushort* buffer, nuint buflen);

        // extern FPDF_BOOL FPDF_ImportPages (FPDF_DOCUMENT dest_doc, FPDF_DOCUMENT src_doc, FPDF_BYTESTRING pagerange, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_ImportPages(FPDF_DOCUMENT* dest_doc, FPDF_DOCUMENT* src_doc, sbyte* pagerange, int index);

        // extern FPDF_DOCUMENT FPDF_ImportNPagesToOne (FPDF_DOCUMENT src_doc, float output_width, float output_height, size_t num_pages_on_x_axis, size_t num_pages_on_y_axis);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_DOCUMENT* FPDF_ImportNPagesToOne(FPDF_DOCUMENT* src_doc, float output_width, float output_height, nuint num_pages_on_x_axis, nuint num_pages_on_y_axis);

        // extern FPDF_BOOL FPDF_CopyViewerPreferences (FPDF_DOCUMENT dest_doc, FPDF_DOCUMENT src_doc);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_CopyViewerPreferences(FPDF_DOCUMENT* dest_doc, FPDF_DOCUMENT* src_doc);

        // extern int FPDF_RenderPageBitmapWithColorScheme_Start (FPDF_BITMAP bitmap, FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags, const FPDF_COLORSCHEME *color_scheme, IFSDK_PAUSE *pause);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_RenderPageBitmapWithColorScheme_Start(FPDF_BITMAP* bitmap, FPDF_PAGE* page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags, FPDF_COLORSCHEME* color_scheme, IFSDK_PAUSE* pause);

        // extern int FPDF_RenderPageBitmap_Start (FPDF_BITMAP bitmap, FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags, IFSDK_PAUSE *pause);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_RenderPageBitmap_Start(FPDF_BITMAP* bitmap, FPDF_PAGE* page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags, IFSDK_PAUSE* pause);

        // extern int FPDF_RenderPage_Continue (FPDF_PAGE page, IFSDK_PAUSE *pause);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_RenderPage_Continue(FPDF_PAGE* page, IFSDK_PAUSE* pause);

        // extern void FPDF_RenderPage_Close (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_RenderPage_Close(FPDF_PAGE* page);

        // extern FPDF_BOOL FPDF_SaveAsCopy (FPDF_DOCUMENT document, FPDF_FILEWRITE *pFileWrite, FPDF_DWORD flags);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_SaveAsCopy(FPDF_DOCUMENT* document, FPDF_FILEWRITE* pFileWrite, nuint flags);

        // extern FPDF_BOOL FPDF_SaveWithVersion (FPDF_DOCUMENT document, FPDF_FILEWRITE *pFileWrite, FPDF_DWORD flags, int fileVersion);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_SaveWithVersion(FPDF_DOCUMENT* document, FPDF_FILEWRITE* pFileWrite, nuint flags, int fileVersion);

        // extern int FPDFText_GetCharIndexFromTextIndex (FPDF_TEXTPAGE text_page, int nTextIndex);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetCharIndexFromTextIndex(FPDF_TEXTPAGE* text_page, int nTextIndex);

        // extern int FPDFText_GetTextIndexFromCharIndex (FPDF_TEXTPAGE text_page, int nCharIndex);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetTextIndexFromCharIndex(FPDF_TEXTPAGE* text_page, int nCharIndex);

        // extern int FPDF_GetSignatureCount (FPDF_DOCUMENT document);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_GetSignatureCount(FPDF_DOCUMENT* document);

        // extern FPDF_SIGNATURE FPDF_GetSignatureObject (FPDF_DOCUMENT document, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_SIGNATURE* FPDF_GetSignatureObject(FPDF_DOCUMENT* document, int index);

        // extern unsigned long FPDFSignatureObj_GetContents (FPDF_SIGNATURE signature, void *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFSignatureObj_GetContents(FPDF_SIGNATURE* signature, void* buffer, nuint length);

        // extern unsigned long FPDFSignatureObj_GetByteRange (FPDF_SIGNATURE signature, int *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFSignatureObj_GetByteRange(FPDF_SIGNATURE* signature, int* buffer, nuint length);

        // extern unsigned long FPDFSignatureObj_GetSubFilter (FPDF_SIGNATURE signature, char *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFSignatureObj_GetSubFilter(FPDF_SIGNATURE* signature, sbyte* buffer, nuint length);

        // extern unsigned long FPDFSignatureObj_GetReason (FPDF_SIGNATURE signature, void *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFSignatureObj_GetReason(FPDF_SIGNATURE* signature, void* buffer, nuint length);

        // extern unsigned long FPDFSignatureObj_GetTime (FPDF_SIGNATURE signature, char *buffer, unsigned long length);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFSignatureObj_GetTime(FPDF_SIGNATURE* signature, sbyte* buffer, nuint length);

        // extern unsigned int FPDFSignatureObj_GetDocMDPPermission (FPDF_SIGNATURE signature);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe uint FPDFSignatureObj_GetDocMDPPermission(FPDF_SIGNATURE* signature);

        // extern FPDF_STRUCTTREE FPDF_StructTree_GetForPage (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_STRUCTTREE* FPDF_StructTree_GetForPage(FPDF_PAGE* page);

        // extern void FPDF_StructTree_Close (FPDF_STRUCTTREE struct_tree);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_StructTree_Close(FPDF_STRUCTTREE* struct_tree);

        // extern int FPDF_StructTree_CountChildren (FPDF_STRUCTTREE struct_tree);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_StructTree_CountChildren(FPDF_STRUCTTREE* struct_tree);

        // extern FPDF_STRUCTELEMENT FPDF_StructTree_GetChildAtIndex (FPDF_STRUCTTREE struct_tree, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_STRUCTELEMENT* FPDF_StructTree_GetChildAtIndex(FPDF_STRUCTTREE* struct_tree, int index);

        // extern unsigned long FPDF_StructElement_GetAltText (FPDF_STRUCTELEMENT struct_element, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_StructElement_GetAltText(FPDF_STRUCTELEMENT* struct_element, void* buffer, nuint buflen);

        // extern unsigned long FPDF_StructElement_GetID (FPDF_STRUCTELEMENT struct_element, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_StructElement_GetID(FPDF_STRUCTELEMENT* struct_element, void* buffer, nuint buflen);

        // extern unsigned long FPDF_StructElement_GetLang (FPDF_STRUCTELEMENT struct_element, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_StructElement_GetLang(FPDF_STRUCTELEMENT* struct_element, void* buffer, nuint buflen);

        // extern unsigned long FPDF_StructElement_GetStringAttribute (FPDF_STRUCTELEMENT struct_element, FPDF_BYTESTRING attr_name, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_StructElement_GetStringAttribute(FPDF_STRUCTELEMENT* struct_element, sbyte* attr_name, void* buffer, nuint buflen);

        // extern int FPDF_StructElement_GetMarkedContentID (FPDF_STRUCTELEMENT struct_element);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_StructElement_GetMarkedContentID(FPDF_STRUCTELEMENT* struct_element);

        // extern unsigned long FPDF_StructElement_GetType (FPDF_STRUCTELEMENT struct_element, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_StructElement_GetType(FPDF_STRUCTELEMENT* struct_element, void* buffer, nuint buflen);

        // extern unsigned long FPDF_StructElement_GetTitle (FPDF_STRUCTELEMENT struct_element, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDF_StructElement_GetTitle(FPDF_STRUCTELEMENT* struct_element, void* buffer, nuint buflen);

        // extern int FPDF_StructElement_CountChildren (FPDF_STRUCTELEMENT struct_element);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDF_StructElement_CountChildren(FPDF_STRUCTELEMENT* struct_element);

        // extern FPDF_STRUCTELEMENT FPDF_StructElement_GetChildAtIndex (FPDF_STRUCTELEMENT struct_element, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_STRUCTELEMENT* FPDF_StructElement_GetChildAtIndex(FPDF_STRUCTELEMENT* struct_element, int index);

        // extern const FPDF_CharsetFontMap * FPDF_GetDefaultTTFMap ();
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_CharsetFontMap* FPDF_GetDefaultTTFMap();

        // extern void FPDF_AddInstalledFont (void *mapper, const char *face, int charset);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_AddInstalledFont(void* mapper, sbyte* face, int charset);

        // extern void FPDF_SetSystemFontInfo (FPDF_SYSFONTINFO *pFontInfo);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_SetSystemFontInfo(FPDF_SYSFONTINFO* pFontInfo);

        // extern FPDF_SYSFONTINFO * FPDF_GetDefaultSystemFontInfo ();
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_SYSFONTINFO* FPDF_GetDefaultSystemFontInfo();

        // extern void FPDF_FreeDefaultSystemFontInfo (FPDF_SYSFONTINFO *pFontInfo);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_FreeDefaultSystemFontInfo(FPDF_SYSFONTINFO* pFontInfo);

        // extern FPDF_TEXTPAGE FPDFText_LoadPage (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_TEXTPAGE* FPDFText_LoadPage(FPDF_PAGE* page);

        // extern void FPDFText_ClosePage (FPDF_TEXTPAGE text_page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFText_ClosePage(FPDF_TEXTPAGE* text_page);

        // extern int FPDFText_CountChars (FPDF_TEXTPAGE text_page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_CountChars(FPDF_TEXTPAGE* text_page);

        // extern unsigned int FPDFText_GetUnicode (FPDF_TEXTPAGE text_page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe uint FPDFText_GetUnicode(FPDF_TEXTPAGE* text_page, int index);

        // extern double FPDFText_GetFontSize (FPDF_TEXTPAGE text_page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe double FPDFText_GetFontSize(FPDF_TEXTPAGE* text_page, int index);

        // extern unsigned long FPDFText_GetFontInfo (FPDF_TEXTPAGE text_page, int index, void *buffer, unsigned long buflen, int *flags);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFText_GetFontInfo(FPDF_TEXTPAGE* text_page, int index, void* buffer, nuint buflen, int* flags);

        // extern int FPDFText_GetFontWeight (FPDF_TEXTPAGE text_page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetFontWeight(FPDF_TEXTPAGE* text_page, int index);

        // extern FPDF_TEXT_RENDERMODE FPDFText_GetTextRenderMode (FPDF_TEXTPAGE text_page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FpdfTextRendermode FPDFText_GetTextRenderMode(FPDF_TEXTPAGE* text_page, int index);

        // extern FPDF_BOOL FPDFText_GetFillColor (FPDF_TEXTPAGE text_page, int index, unsigned int *R, unsigned int *G, unsigned int *B, unsigned int *A);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetFillColor(FPDF_TEXTPAGE* text_page, int index, uint* R, uint* G, uint* B, uint* A);

        // extern FPDF_BOOL FPDFText_GetStrokeColor (FPDF_TEXTPAGE text_page, int index, unsigned int *R, unsigned int *G, unsigned int *B, unsigned int *A);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetStrokeColor(FPDF_TEXTPAGE* text_page, int index, uint* R, uint* G, uint* B, uint* A);

        // extern float FPDFText_GetCharAngle (FPDF_TEXTPAGE text_page, int index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe float FPDFText_GetCharAngle(FPDF_TEXTPAGE* text_page, int index);

        // extern FPDF_BOOL FPDFText_GetCharBox (FPDF_TEXTPAGE text_page, int index, double *left, double *right, double *bottom, double *top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetCharBox(FPDF_TEXTPAGE* text_page, int index, double* left, double* right, double* bottom, double* top);

        // extern FPDF_BOOL FPDFText_GetLooseCharBox (FPDF_TEXTPAGE text_page, int index, FS_RECTF *rect);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetLooseCharBox(FPDF_TEXTPAGE* text_page, int index, FS_RECTF* rect);

        // extern FPDF_BOOL FPDFText_GetMatrix (FPDF_TEXTPAGE text_page, int index, FS_MATRIX *matrix);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetMatrix(FPDF_TEXTPAGE* text_page, int index, FS_MATRIX* matrix);

        // extern FPDF_BOOL FPDFText_GetCharOrigin (FPDF_TEXTPAGE text_page, int index, double *x, double *y);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetCharOrigin(FPDF_TEXTPAGE* text_page, int index, double* x, double* y);

        // extern int FPDFText_GetCharIndexAtPos (FPDF_TEXTPAGE text_page, double x, double y, double xTolerance, double yTolerance);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetCharIndexAtPos(FPDF_TEXTPAGE* text_page, double x, double y, double xTolerance, double yTolerance);

        // extern int FPDFText_GetText (FPDF_TEXTPAGE text_page, int start_index, int count, unsigned short *result);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetText(FPDF_TEXTPAGE* text_page, int start_index, int count, ushort* result);

        // extern int FPDFText_CountRects (FPDF_TEXTPAGE text_page, int start_index, int count);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_CountRects(FPDF_TEXTPAGE* text_page, int start_index, int count);

        // extern FPDF_BOOL FPDFText_GetRect (FPDF_TEXTPAGE text_page, int rect_index, double *left, double *top, double *right, double *bottom);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetRect(FPDF_TEXTPAGE* text_page, int rect_index, double* left, double* top, double* right, double* bottom);

        // extern int FPDFText_GetBoundedText (FPDF_TEXTPAGE text_page, double left, double top, double right, double bottom, unsigned short *buffer, int buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetBoundedText(FPDF_TEXTPAGE* text_page, double left, double top, double right, double bottom, ushort* buffer, int buflen);

        // extern FPDF_SCHHANDLE FPDFText_FindStart (FPDF_TEXTPAGE text_page, FPDF_WIDESTRING findwhat, unsigned long flags, int start_index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_SCHHANDLE* FPDFText_FindStart(FPDF_TEXTPAGE* text_page, ushort* findwhat, nuint flags, int start_index);

        // extern FPDF_BOOL FPDFText_FindNext (FPDF_SCHHANDLE handle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_FindNext(FPDF_SCHHANDLE* handle);

        // extern FPDF_BOOL FPDFText_FindPrev (FPDF_SCHHANDLE handle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_FindPrev(FPDF_SCHHANDLE* handle);

        // extern int FPDFText_GetSchResultIndex (FPDF_SCHHANDLE handle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetSchResultIndex(FPDF_SCHHANDLE* handle);

        // extern int FPDFText_GetSchCount (FPDF_SCHHANDLE handle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFText_GetSchCount(FPDF_SCHHANDLE* handle);

        // extern void FPDFText_FindClose (FPDF_SCHHANDLE handle);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFText_FindClose(FPDF_SCHHANDLE* handle);

        // extern FPDF_PAGELINK FPDFLink_LoadWebLinks (FPDF_TEXTPAGE text_page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PAGELINK* FPDFLink_LoadWebLinks(FPDF_TEXTPAGE* text_page);

        // extern int FPDFLink_CountWebLinks (FPDF_PAGELINK link_page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_CountWebLinks(FPDF_PAGELINK* link_page);

        // extern int FPDFLink_GetURL (FPDF_PAGELINK link_page, int link_index, unsigned short *buffer, int buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_GetURL(FPDF_PAGELINK* link_page, int link_index, ushort* buffer, int buflen);

        // extern int FPDFLink_CountRects (FPDF_PAGELINK link_page, int link_index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_CountRects(FPDF_PAGELINK* link_page, int link_index);

        // extern FPDF_BOOL FPDFLink_GetRect (FPDF_PAGELINK link_page, int link_index, int rect_index, double *left, double *top, double *right, double *bottom);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_GetRect(FPDF_PAGELINK* link_page, int link_index, int rect_index, double* left, double* top, double* right, double* bottom);

        // extern FPDF_BOOL FPDFLink_GetTextRange (FPDF_PAGELINK link_page, int link_index, int *start_char_index, int *char_count);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFLink_GetTextRange(FPDF_PAGELINK* link_page, int link_index, int* start_char_index, int* char_count);

        // extern void FPDFLink_CloseWebLinks (FPDF_PAGELINK link_page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFLink_CloseWebLinks(FPDF_PAGELINK* link_page);

        // extern unsigned long FPDFPage_GetDecodedThumbnailData (FPDF_PAGE page, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFPage_GetDecodedThumbnailData(FPDF_PAGE* page, void* buffer, nuint buflen);

        // extern unsigned long FPDFPage_GetRawThumbnailData (FPDF_PAGE page, void *buffer, unsigned long buflen);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe nuint FPDFPage_GetRawThumbnailData(FPDF_PAGE* page, void* buffer, nuint buflen);

        // extern FPDF_BITMAP FPDFPage_GetThumbnailAsBitmap (FPDF_PAGE page);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_BITMAP* FPDFPage_GetThumbnailAsBitmap(FPDF_PAGE* page);

        // extern void FPDFPage_SetMediaBox (FPDF_PAGE page, float left, float bottom, float right, float top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_SetMediaBox(FPDF_PAGE* page, float left, float bottom, float right, float top);

        // extern void FPDFPage_SetCropBox (FPDF_PAGE page, float left, float bottom, float right, float top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_SetCropBox(FPDF_PAGE* page, float left, float bottom, float right, float top);

        // extern void FPDFPage_SetBleedBox (FPDF_PAGE page, float left, float bottom, float right, float top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_SetBleedBox(FPDF_PAGE* page, float left, float bottom, float right, float top);

        // extern void FPDFPage_SetTrimBox (FPDF_PAGE page, float left, float bottom, float right, float top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_SetTrimBox(FPDF_PAGE* page, float left, float bottom, float right, float top);

        // extern void FPDFPage_SetArtBox (FPDF_PAGE page, float left, float bottom, float right, float top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_SetArtBox(FPDF_PAGE* page, float left, float bottom, float right, float top);

        // extern FPDF_BOOL FPDFPage_GetMediaBox (FPDF_PAGE page, float *left, float *bottom, float *right, float *top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GetMediaBox(FPDF_PAGE* page, float* left, float* bottom, float* right, float* top);

        // extern FPDF_BOOL FPDFPage_GetCropBox (FPDF_PAGE page, float *left, float *bottom, float *right, float *top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GetCropBox(FPDF_PAGE* page, float* left, float* bottom, float* right, float* top);

        // extern FPDF_BOOL FPDFPage_GetBleedBox (FPDF_PAGE page, float *left, float *bottom, float *right, float *top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GetBleedBox(FPDF_PAGE* page, float* left, float* bottom, float* right, float* top);

        // extern FPDF_BOOL FPDFPage_GetTrimBox (FPDF_PAGE page, float *left, float *bottom, float *right, float *top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GetTrimBox(FPDF_PAGE* page, float* left, float* bottom, float* right, float* top);

        // extern FPDF_BOOL FPDFPage_GetArtBox (FPDF_PAGE page, float *left, float *bottom, float *right, float *top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_GetArtBox(FPDF_PAGE* page, float* left, float* bottom, float* right, float* top);

        // extern FPDF_BOOL FPDFPage_TransFormWithClip (FPDF_PAGE page, const FS_MATRIX *matrix, const FS_RECTF *clipRect);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFPage_TransFormWithClip(FPDF_PAGE* page, FS_MATRIX* matrix, FS_RECTF* clipRect);

        // extern void FPDFPageObj_TransformClipPath (FPDF_PAGEOBJECT page_object, double a, double b, double c, double d, double e, double f);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPageObj_TransformClipPath(FPDF_PAGEOBJECT* page_object, double a, double b, double c, double d, double e, double f);

        // extern FPDF_CLIPPATH FPDFPageObj_GetClipPath (FPDF_PAGEOBJECT page_object);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_CLIPPATH* FPDFPageObj_GetClipPath(FPDF_PAGEOBJECT* page_object);

        // extern int FPDFClipPath_CountPaths (FPDF_CLIPPATH clip_path);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFClipPath_CountPaths(FPDF_CLIPPATH* clip_path);

        // extern int FPDFClipPath_CountPathSegments (FPDF_CLIPPATH clip_path, int path_index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe int FPDFClipPath_CountPathSegments(FPDF_CLIPPATH* clip_path, int path_index);

        // extern FPDF_PATHSEGMENT FPDFClipPath_GetPathSegment (FPDF_CLIPPATH clip_path, int path_index, int segment_index);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_PATHSEGMENT* FPDFClipPath_GetPathSegment(FPDF_CLIPPATH* clip_path, int path_index, int segment_index);

        // extern FPDF_CLIPPATH FPDF_CreateClipPath (float left, float bottom, float right, float top);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe FPDF_CLIPPATH* FPDF_CreateClipPath(float left, float bottom, float right, float top);

        // extern void FPDF_DestroyClipPath (FPDF_CLIPPATH clipPath);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDF_DestroyClipPath(FPDF_CLIPPATH* clipPath);

        // extern void FPDFPage_InsertClipPath (FPDF_PAGE page, FPDF_CLIPPATH clipPath);
        [DllImport("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern unsafe void FPDFPage_InsertClipPath(FPDF_PAGE* page, FPDF_CLIPPATH* clipPath);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_LIBRARY_CONFIG
    {
        public int version;

        public unsafe sbyte** m_pUserFontPaths;

        public unsafe void* m_pIsolate;

        public uint m_v8EmbedderSlot;

        public unsafe void* m_pPlatform;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_FILEACCESS
    {
        public nuint m_FileLen;

        public unsafe Func<void*, nuint, byte*, nuint, int>* m_GetBlock;

        public unsafe void* m_Param;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_FILEHANDLER
    {
        public unsafe void* clientData;

        public unsafe Action<void*>* Release;

        public unsafe Func<void*, nuint>* GetSize;

        public unsafe Func<void*, nuint, void*, nuint, int>* ReadBlock;

        public unsafe Func<void*, nuint, void*, nuint, int>* WriteBlock;

        public unsafe Func<void*, int>* Flush;

        public unsafe Func<void*, nuint, int>* Truncate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_COLORSCHEME
    {
        public nuint path_fill_color;

        public nuint path_stroke_color;

        public nuint text_fill_color;

        public nuint text_stroke_color;
    }

    public enum FpdfFileidtype : uint
    {
        Permanent = 0,
        Changing = 1
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FS_QUADPOINTSF
    {
        public float x1;

        public float y1;

        public float x2;

        public float y2;

        public float x3;

        public float y3;

        public float x4;

        public float y4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IPDF_JSPLATFORM
    {
        public int version;

        public unsafe Func<_IPDF_JsPlatform*, ushort*, ushort*, int, int, int>* app_alert;

        public unsafe Action<_IPDF_JsPlatform*, int>* app_beep;

        public unsafe Func<_IPDF_JsPlatform*, ushort*, ushort*, ushort*, ushort*, int, void*, int, int>* app_response;

        public unsafe Func<_IPDF_JsPlatform*, void*, int, int>* Doc_getFilePath;

        public unsafe Action<_IPDF_JsPlatform*, void*, int, int, ushort*, ushort*, ushort*, ushort*, ushort*>* Doc_mail;

        public unsafe Action<_IPDF_JsPlatform*, int, int, int, int, int, int, int, int>* Doc_print;

        public unsafe Action<_IPDF_JsPlatform*, void*, int, ushort*>* Doc_submitForm;

        public unsafe Action<_IPDF_JsPlatform*, int>* Doc_gotoPage;

        public unsafe Func<_IPDF_JsPlatform*, void*, int, int>* Field_browse;

        public unsafe void* m_pFormfillinfo;

        public unsafe void* m_isolate;

        public uint m_v8EmbedderSlot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_SYSTEMTIME
    {
        public ushort wYear;

        public ushort wMonth;

        public ushort wDayOfWeek;

        public ushort wDay;

        public ushort wHour;

        public ushort wMinute;

        public ushort wSecond;

        public ushort wMilliseconds;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_FORMFILLINFO
    {
        public int version;

        public unsafe Action<_FPDF_FORMFILLINFO*>* Release;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_PAGE*, double, double, double, double>* FFI_Invalidate;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_PAGE*, double, double, double, double>* FFI_OutputSelectedRect;

        public unsafe Action<_FPDF_FORMFILLINFO*, int>* FFI_SetCursor;

        public unsafe Func<_FPDF_FORMFILLINFO*, int, TimerCallback*, int>* FFI_SetTimer;

        public unsafe Action<_FPDF_FORMFILLINFO*, int>* FFI_KillTimer;

        public unsafe Func<_FPDF_FORMFILLINFO*, FPDF_SYSTEMTIME>* FFI_GetLocalTime;

        public unsafe Action<_FPDF_FORMFILLINFO*>* FFI_OnChange;

        public unsafe Func<_FPDF_FORMFILLINFO*, FPDF_DOCUMENT*, int, FPDF_PAGE*>* FFI_GetPage;

        public unsafe Func<_FPDF_FORMFILLINFO*, FPDF_DOCUMENT*, FPDF_PAGE*>* FFI_GetCurrentPage;

        public unsafe Func<_FPDF_FORMFILLINFO*, FPDF_PAGE*, int>* FFI_GetRotation;

        public unsafe Action<_FPDF_FORMFILLINFO*, sbyte*>* FFI_ExecuteNamedAction;

        public unsafe Action<_FPDF_FORMFILLINFO*, ushort*, nuint, int>* FFI_SetTextFieldFocus;

        public unsafe Action<_FPDF_FORMFILLINFO*, sbyte*>* FFI_DoURIAction;

        public unsafe Action<_FPDF_FORMFILLINFO*, int, int, float*, int>* FFI_DoGoToAction;

        public unsafe IPDF_JSPLATFORM* m_pJsPlatform;

        public int xfa_disabled;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_PAGE*, int, double, double, double, double>* FFI_DisplayCaret;

        public unsafe Func<_FPDF_FORMFILLINFO*, FPDF_DOCUMENT*, int>* FFI_GetCurrentPageIndex;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_DOCUMENT*, int>* FFI_SetCurrentPage;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_DOCUMENT*, ushort*>* FFI_GotoURL;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_PAGE*, double*, double*, double*, double*>* FFI_GetPageViewRect;

        public unsafe Action<_FPDF_FORMFILLINFO*, int, nuint>* FFI_PageEvent;

        public unsafe Func<_FPDF_FORMFILLINFO*, FPDF_PAGE*, FPDF_WIDGET*, int, float, float, int>* FFI_PopupMenu;

        public unsafe Func<_FPDF_FORMFILLINFO*, int, ushort*, sbyte*, FPDF_FILEHANDLER*>* FFI_OpenFile;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_FILEHANDLER*, ushort*, ushort*, ushort*, ushort*, ushort*>* FFI_EmailTo;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_FILEHANDLER*, int, ushort*>* FFI_UploadTo;

        public unsafe Func<_FPDF_FORMFILLINFO*, void*, int, int>* FFI_GetPlatform;

        public unsafe Func<_FPDF_FORMFILLINFO*, void*, int, int>* FFI_GetLanguage;

        public unsafe Func<_FPDF_FORMFILLINFO*, ushort*, FPDF_FILEHANDLER*>* FFI_DownloadFromURL;

        public unsafe Func<_FPDF_FORMFILLINFO*, ushort*, ushort*, ushort*, ushort*, ushort*, FPDF_BSTR*, int>* FFI_PostRequestURL;

        public unsafe Func<_FPDF_FORMFILLINFO*, ushort*, ushort*, ushort*, int>* FFI_PutRequestURL;

        public unsafe Action<_FPDF_FORMFILLINFO*, FPDF_ANNOTATION*, int>* FFI_OnFocusChange;

        public unsafe Action<_FPDF_FORMFILLINFO*, sbyte*, int>* FFI_DoURIActionWithKeyboardModifier;
    }

    public enum FpdfannotColortype : uint
    {
        Color = 0,
        InteriorColor
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FX_FILEAVAIL
    {
        public int version;

        public unsafe Func<_FX_FILEAVAIL*, nuint, nuint, int>* IsDataAvail;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FX_DOWNLOADHINTS
    {
        public int version;

        public unsafe Action<_FX_DOWNLOADHINTS*, nuint, nuint>* AddSegment;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_IMAGEOBJ_METADATA
    {
        public uint width;

        public uint height;

        public float horizontal_dpi;

        public float vertical_dpi;

        public uint bits_per_pixel;

        public int colorspace;

        public int marked_content_id;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UNSUPPORT_INFO
    {
        public int version;

        public unsafe Action<_UNSUPPORT_INFO*, int>* FSDK_UnSupport_Handler;
    }

    public enum FwlEventflag : uint
    {
        ShiftKey = 1 << 0,
        ControlKey = 1 << 1,
        AltKey = 1 << 2,
        MetaKey = 1 << 3,
        KeyPad = 1 << 4,
        AutoRepeat = 1 << 5,
        LeftButtonDown = 1 << 6,
        MiddleButtonDown = 1 << 7,
        RightButtonDown = 1 << 8
    }

    public enum FwlVkeycode : uint
    {
        Back = 8,
        Tab = 9,
        NewLine = 10,
        Clear = 12,
        Return = 13,
        Shift = 16,
        Control = 17,
        Menu = 18,
        Pause = 19,
        Capital = 20,
        Kana = 21,
        Hangul = 21,
        Junja = 23,
        Final = 24,
        Hanja = 25,
        Kanji = 25,
        Escape = 27,
        Convert = 28,
        NonConvert = 29,
        Accept = 30,
        ModeChange = 31,
        Space = 32,
        Prior = 33,
        Next = 34,
        End = 35,
        Home = 36,
        Left = 37,
        Up = 38,
        Right = 39,
        Down = 40,
        Select = 41,
        Print = 42,
        Execute = 43,
        Snapshot = 44,
        Insert = 45,
        Delete = 46,
        Help = 47,
        FwlVkey0 = 48,
        FwlVkey1 = 49,
        FwlVkey2 = 50,
        FwlVkey3 = 51,
        FwlVkey4 = 52,
        FwlVkey5 = 53,
        FwlVkey6 = 54,
        FwlVkey7 = 55,
        FwlVkey8 = 56,
        FwlVkey9 = 57,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LWin = 91,
        Command = 91,
        RWin = 92,
        Apps = 93,
        Sleep = 95,
        NumPad0 = 96,
        NumPad1 = 97,
        NumPad2 = 98,
        NumPad3 = 99,
        NumPad4 = 100,
        NumPad5 = 101,
        NumPad6 = 102,
        NumPad7 = 103,
        NumPad8 = 104,
        NumPad9 = 105,
        Multiply = 106,
        Add = 107,
        Separator = 108,
        Subtract = 109,
        Decimal = 110,
        Divide = 111,
        F1 = 112,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F13 = 124,
        F14 = 125,
        F15 = 126,
        F16 = 127,
        F17 = 128,
        F18 = 129,
        F19 = 130,
        F20 = 131,
        F21 = 132,
        F22 = 133,
        F23 = 134,
        F24 = 135,
        NunLock = 144,
        Scroll = 145,
        LShift = 160,
        RShift = 161,
        LControl = 162,
        RControl = 163,
        LMenu = 164,
        RMenu = 165,
        BROWSER_Back = 166,
        BROWSER_Forward = 167,
        BROWSER_Refresh = 168,
        BROWSER_Stop = 169,
        BROWSER_Search = 170,
        BROWSER_Favorites = 171,
        BROWSER_Home = 172,
        VOLUME_Mute = 173,
        VOLUME_Down = 174,
        VOLUME_Up = 175,
        MEDIA_NEXT_Track = 176,
        MEDIA_PREV_Track = 177,
        MEDIA_Stop = 178,
        MEDIA_PLAY_Pause = 179,
        MEDIA_LAUNCH_Mail = 180,
        MEDIA_LAUNCH_MEDIA_Select = 181,
        MediaLaunchApp1 = 182,
        MediaLaunchApp2 = 183,
        Oem1 = 186,
        OEM_Plus = 187,
        OEM_Comma = 188,
        OEM_Minus = 189,
        OEM_Period = 190,
        Oem2 = 191,
        Oem3 = 192,
        Oem4 = 219,
        Oem5 = 220,
        Oem6 = 221,
        Oem7 = 222,
        Oem8 = 223,
        Oem102 = 226,
        ProcessKey = 229,
        Packet = 231,
        Attn = 246,
        Crsel = 247,
        Exsel = 248,
        Ereof = 249,
        Play = 250,
        Zoom = 251,
        NoName = 252,
        Pa1 = 253,
        OEM_Clear = 254,
        Unknown = 0
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IFSDK_PAUSE
    {
        public int version;

        public unsafe Func<_IFSDK_PAUSE*, int>* NeedToPauseNow;

        public unsafe void* user;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_FILEWRITE
    {
        public int version;

        public unsafe Func<FPDF_FILEWRITE_*, void*, nuint, int>* WriteBlock;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_SYSFONTINFO
    {
        public int version;

        public unsafe Action<_FPDF_SYSFONTINFO*>* Release;

        public unsafe Action<_FPDF_SYSFONTINFO*, void*>* EnumFonts;

        public unsafe Func<_FPDF_SYSFONTINFO*, int, int, int, int, sbyte*, int*, void*>* MapFont;

        public unsafe Func<_FPDF_SYSFONTINFO*, sbyte*, void*>* GetFont;

        public unsafe Func<_FPDF_SYSFONTINFO*, void*, uint, byte*, nuint, nuint>* GetFontData;

        public unsafe Func<_FPDF_SYSFONTINFO*, void*, sbyte*, nuint, nuint>* GetFaceName;

        public unsafe Func<_FPDF_SYSFONTINFO*, void*, int>* GetFontCharset;

        public unsafe Action<_FPDF_SYSFONTINFO*, void*>* DeleteFont;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_CharsetFontMap
    {
        public int charset;

        public unsafe sbyte* fontname;
    }
}
*/